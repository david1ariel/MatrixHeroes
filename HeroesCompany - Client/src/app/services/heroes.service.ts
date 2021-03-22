import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HeroModel } from '../models/hero.model';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
  providedIn: 'root'
})
export class HeroesService {

  constructor(private http: HttpClient) { }

  public async getAllHeroesByTrainerId() {
    try {
      const heroes: HeroModel[] = await this.http.get<HeroModel[]>(environment.heroesBaseUrl + "/" + store.getState().trainer.trainerId).toPromise();
      console.log(heroes);
      store.dispatch({ type: ActionType.GetAllHeroesByTrainerId, payload: heroes });
      return true;
    }
    catch (httpErrorResponse) {
      console.dir(httpErrorResponse);
      return false;
    }
  }

  public async addHero(heroToAdd: HeroModel) {
    try {
      heroToAdd.trainerId = store.getState().trainer.trainerId;
      const addedHero: HeroModel = await this.http.post<HeroModel>(environment.heroesBaseUrl, heroToAdd).toPromise();
      console.log(addedHero);
      store.dispatch({ type: ActionType.AddHero, payload: addedHero });
      return true;
    } catch (httpErrorResponse) {
      console.dir(httpErrorResponse);
      return false;
    }
  }

  public async deleteHero(heroId: string) {
    try {
      await this.http.delete(environment.heroesBaseUrl + "/" + heroId).toPromise();
      console.log("deleted");
      store.dispatch({type: ActionType.DeleteHero, payload: heroId})
    } catch (httpErrorResponse) {
      console.dir(httpErrorResponse);
      return false;
    }


  }
}
