export class Voyage{
  constructor(public id:number,
              public destination:string,
              public img:string,
              public isPublic:boolean,
              public isOwner:boolean) {
  }
}

export class ShareDTO{
  constructor(public id:number,
              public img:string,
              public destination:string,
              public isPublic:boolean,
              public newUserEmail:string) {
  }
}
