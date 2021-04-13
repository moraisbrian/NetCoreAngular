import { Directive, ElementRef, Renderer2, AfterContentChecked, OnInit } from '@angular/core';

@Directive({
  selector: '[showIfLogged]'
})
export class ShowIfLoggedDirective implements AfterContentChecked, OnInit {

  constructor(private el: ElementRef, private renderer: Renderer2) { }

  ngOnInit() {
    this.verificarLogin();
  }

  ngAfterContentChecked() {
    this.verificarLogin();
  }

  private verificarLogin() {
    if (!localStorage.getItem('token')) {
      this.renderer.setStyle(this.el.nativeElement, 'display', 'none');
    } else {
      this.renderer.setStyle(this.el.nativeElement, 'display', 'block');
    }
  }
  
}
