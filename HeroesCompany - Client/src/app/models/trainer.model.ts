export class TrainerModel{
  public constructor(
    public trainerId?: string,
    public name?: string,
    public username?: string,
    public password?: string,
    public jwtToken?: string
  ){ }
}
