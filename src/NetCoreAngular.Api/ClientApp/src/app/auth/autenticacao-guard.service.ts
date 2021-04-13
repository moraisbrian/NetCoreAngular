import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import getLocalDate from '../shared/getLocalDate';

@Injectable()
export class AutenticacaoGuardService implements CanActivate {

  constructor(private router: Router) { }

  canActivate(): boolean {
    if (localStorage.getItem('token') && localStorage.getItem('expiracao-token')) {
      const expiracao = new Date(localStorage.getItem('expiracao-token'));
      const agora = getLocalDate();
      if (expiracao > agora) {
        return true;
      } else {
        localStorage.clear();
        this.router.navigate(['/']);
        return false;
      }
    } else {
      localStorage.clear();
      this.router.navigate(['/']);
      return false;
    }
  }

}
