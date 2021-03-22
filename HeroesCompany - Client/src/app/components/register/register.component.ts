import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TrainerModel } from 'src/app/models/trainer.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public trainer: TrainerModel;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.trainer = new TrainerModel();
  }

  public async register() {
    const success = await this.authService.register(this.trainer);
    if(success) {
        this.router.navigateByUrl("/heroes");
    }
}
}
