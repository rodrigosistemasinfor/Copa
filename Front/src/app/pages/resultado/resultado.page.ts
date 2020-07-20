import { Component, OnInit } from '@angular/core';
import { EquipeModel } from 'src/app/model/equipe.model';
import { Router } from '@angular/router';

@Component({
  selector: 'resultado-page',
  templateUrl: './resultado.page.html',
  styleUrls: ['./resultado.page.css']
})
export class ResultadoPage implements OnInit {

  public listaGanhadoras : EquipeModel[] = [];

  constructor(private _router: Router) { }

  ngOnInit() {
    const resultado = history.state.data;

    if(resultado)
      this.listaGanhadoras = resultado as EquipeModel[];
    else
      this._router.navigate(['home']);
  }
}
