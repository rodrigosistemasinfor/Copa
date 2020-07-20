import { EquipeSeletor } from '../seletor/equipe.seletor';
import { EquipeModel } from '../model/equipe.model';
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ResponseModelDomain } from '../domain/Response.model.domain';

@Injectable({
    providedIn: 'root'
})
export class EquipeService{

    private endPoint: string;

    constructor(private http: HttpClient) {
        this.endPoint =  `${environment.ApiUrl}equipe`;
    }

    createEntity(input: any): EquipeModel {
        return new EquipeModel(input.data || input);
    }

     list(data: EquipeSeletor): Observable<ResponseModelDomain<EquipeModel>>{
        return this.http.post<any>(this.endPoint + "/list", data)
               .pipe(
                    map(res => {
                        const responseData  ={
                           Data : res.data.map(pp => this.createEntity(pp) as EquipeModel),
                           TotalRows : res.count
                        }  as ResponseModelDomain<EquipeModel>;
                    
                        return responseData;
                    })
                );
      }
}
