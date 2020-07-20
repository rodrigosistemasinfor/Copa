import { Component, OnInit } from '@angular/core';
import { EquipeService } from 'src/app/services/equipe.service';
import { EquipeSeletor } from 'src/app/seletor/equipe.seletor';
import { EquipeModel } from 'src/app/model/equipe.model';
import { ToastrManager  } from 'ng6-toastr-notifications';
import { CopaService } from 'src/app/services/copa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'equipe-page',
  templateUrl: './equipe.page.html',
  styleUrls: ['./equipe.page.css']
})
export class EquipePage implements OnInit {

  seletor: EquipeSeletor = new EquipeSeletor();
  public listaEquipes: EquipeModel[] = [];
  private listaSelecionadas: EquipeModel[] = [];
  private limeteEquipes = 8;
  public listaGanhadoras : EquipeModel[] = [];

  constructor(
     private _service: EquipeService,
     private _copaService: CopaService,
     public toastr: ToastrManager,
     private _router: Router ) { }

  ngOnInit() {

   this.seletor.RegistroPorPagina = 100;

   this._service.list(this.seletor)
      .subscribe(x => {
         this.listaEquipes = x.Data;
      },
      error => {
        console.log(error);
        this.toastr.errorToastr("Ocorreu um erro em sua solicitação");
      })
  }

  public clickSelect(action: any){
    debugger;
    if(action.event.target.checked && this.listaSelecionadas.length < this.limeteEquipes)
      this.listaSelecionadas.push(action.obj);
    else if(!action.event.target.checked)
      this.listaSelecionadas = this.listaSelecionadas.filter(x=> x.Id != action.obj.Id);
    else{
      this.toastr.infoToastr("O limite de equipes foi atingido, vão ser consideradas as 8 primeiras equipes");
    }
  }

  public processarCopa(){

    let obj = [];

    this.listaSelecionadas.forEach(x => {
      let item = {...x};
      obj.push(item);
    });

    this._copaService.processar(obj)
        .subscribe(result => {
                    this._router.navigate(["resultado"], {state: {data: result.Data}});
                    this.listaGanhadoras = result.Data
                  },
                  error => {
                      console.log(error);
                      this.toastr.errorToastr("Erro ao realizar Copa");
                  });
  }
  
}
