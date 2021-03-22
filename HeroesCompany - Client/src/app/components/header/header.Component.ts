import { Unsubscribe } from 'redux';
import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, HostListener, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { store } from 'src/app/redux/store';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { ActionType } from 'src/app/redux/action-type';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  public unsubscribe: Unsubscribe;
  public trainer = store.getState().trainer;
  public greetings = this.getGreetings();

  constructor(private authService: AuthService, private router: Router, private cdRef:ChangeDetectorRef) { }


  public ngOnInit(): void {
    this.unsubscribe = store.subscribe(() => {
      this.trainer = store.getState().trainer;
      this.greetings = this.getGreetings();

    });
  }

  private getGreetings(): string {
    return "Hello " + (this.trainer ? this.trainer.name : "Guest");
  }

  async logout() {
    await this.authService.logout();
    this.router.navigateByUrl("/home");
  }

  ngOnDestroy(): void {
    this.unsubscribe();
  }
}
