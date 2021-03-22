import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CredentialsModel } from '../models/credentials.model';
import { TrainerModel } from '../models/trainer.model';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public async register(trainer: TrainerModel): Promise<boolean> {
    try {
      const registeredTrainer = await this.http.post(environment.authBaseUrl + "/register", trainer).toPromise();
      store.dispatch({ type: ActionType.Register, payload: registeredTrainer });
      return true;
    }
    catch (httpErrorResponse) {
      store.dispatch({ type: ActionType.GotError, payload: httpErrorResponse });
      return false;
    }
  }

  public async login(credentials: CredentialsModel): Promise<boolean> {
    try {
      const loggedInTrainer = await this.http.post<TrainerModel>(environment.authBaseUrl + "/login", credentials).toPromise();
      store.dispatch({ type: ActionType.Login, payload: loggedInTrainer });
      return true;
    }
    catch (httpErrorResponse) {
      store.dispatch({ type: ActionType.GotError, payload: httpErrorResponse });
      return false;
    }
  }

  public logout(): void {
    store.dispatch({ type: ActionType.Logout });
  }
}
