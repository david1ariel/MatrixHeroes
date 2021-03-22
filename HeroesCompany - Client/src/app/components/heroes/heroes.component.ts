import { Component, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { HeroModel } from 'src/app/models/hero.model';
import { store } from 'src/app/redux/store';
import { HeroesService } from 'src/app/services/heroes.service';

@Component({
  selector: 'app-edit-users',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {

  public heroes = store.getState().heroes;
  public heroToAdd= new HeroModel();
  public unsubscribe: Unsubscribe;

  constructor(private heroesService: HeroesService) { }

  async ngOnInit() {
    this.unsubscribe = store.subscribe(() => this.heroes = store.getState().heroes)
    if(store.getState().heroes.length===0){
      const success = await this.heroesService.getAllHeroesByTrainerId();
    }
  }

  async addHero(){
    const sucess = await this.heroesService.addHero(this.heroToAdd);
    if(sucess){
      alert('Adding Succeeded!');
      this.heroToAdd = new HeroModel();
    }
    else{
      alert('Adding Failed!');
    }
  }

  async deleteHero(e: HeroModel){
    await this.heroesService.deleteHero(e.HeroId);
  }

  clear(){
    this.heroToAdd=new HeroModel();
  }

  async clearChanges(){
    await this.heroesService.getAllHeroesByTrainerId();
  }
}
