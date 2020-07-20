import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routing } from './app.routing';
import { EquipeService } from './services/equipe.service';
import { CopaService } from './services/copa.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardEquipeComponent } from './componente/card-equipe/card-equipe.component';
import { EquipePage } from './pages/equipe/equipe.page';
import { ResultadoPage } from './pages/resultado/resultado.page';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ng6-toastr-notifications';

@NgModule({
  declarations: [
    AppComponent,
    CardEquipeComponent,
    EquipePage,
    ResultadoPage,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
    Routing,
    HttpClientModule,
  ],
  providers: [
    HttpClient,
    EquipeService,
    CopaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
