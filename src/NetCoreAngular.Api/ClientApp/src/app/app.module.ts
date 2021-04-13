import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ChamadosModule } from './chamados/chamados.module';
import { ServiceWorkerModule } from '@angular/service-worker';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfiguracaoModule } from './configuracao/configuracao.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { environment } from '../environments/environment';
import { LoginComponent } from './login/login.component';
import { ShowIfLoggedDirective } from './auth/show-if-logged.directive';
import { RemoveSpecialCharsPipe } from './shared/remove-special-chars.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ShowIfLoggedDirective,
    RemoveSpecialCharsPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ChamadosModule,
    ReactiveFormsModule,
    ConfiguracaoModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
