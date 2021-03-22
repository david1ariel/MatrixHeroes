import { HeroModel } from '../models/hero.model';
import { TrainerModel } from '../models/trainer.model';

export class AppState {

  public trainer: TrainerModel;
  public heroes: HeroModel[]=[];


  public constructor() {
    this.trainer = JSON.parse(sessionStorage.getItem("trainer"));
  }





}
