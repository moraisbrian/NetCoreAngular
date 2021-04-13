import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConfiguracaoService } from '../configuracao/configuracao.service';
import { Franquia } from '../models/franquia.model';

@Component({
  selector: 'app-home',
  styleUrls: ['./home.component.css'],
  templateUrl: './home.component.html',
  providers: [ ConfiguracaoService ]
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(private configuracaoService: ConfiguracaoService) { }

  private subscription: Subscription = new Subscription();

  ngOnInit() {
    if (localStorage.getItem('franquia-atual-id') === '' || localStorage.getItem('franquia-atual') === '') {
      this.subscription = this.configuracaoService.obterFranquias(localStorage.getItem('usuario-id'))
        .subscribe((result: Franquia[]) => {
          localStorage.setItem('franquias-temporario', JSON.stringify(result));
          if (result.length == 1) {
            localStorage.setItem('franquia-atual-id', result[0].id);
            localStorage.setItem('franquia-atual', result[0].nome);
            document.getElementById('btnAtualizarNomeFranquia').click();
          } else {
            document.getElementById('escolherFranquia').click();
          } 
        });
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  // Valores estáticos temporáriamente
  public imagem1: string = '/assets/CarouselImage1.jpg';
  public imagem2: string = '/assets/CarouselImage2.jpg';
  public imagem3: string = '/assets/CarouselImage3.jpg';

  public unidade: string = 'Unidade São Paulo';
  public endereco: string = 'Avenida Paulista - Bela Vista, São Paulo - SP';
  public email: string = 'unidadesaopaulo@netcoreangular.com';
  public telefone: string = '(11) 11111-2222';
}
