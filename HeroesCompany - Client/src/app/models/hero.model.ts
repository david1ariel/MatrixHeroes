export class HeroModel {
  public constructor(
    public HeroId?: string,
    public name?: string,
    public ability?: string,
    public trainStartDate?: Date,
    public suitColors?: string,
    public startingPower?: number,
    public currentPower?: number,
    public trainerId?: string
  ) { }
}
