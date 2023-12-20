export class Voyage {
  constructor(public id: number,
              public destination: string,
              public couverture: Photo,
              public isPublic: boolean,
              public isOwner: boolean) {
  }
}

export class ShareDTO {
  constructor(public id: number,
              public destination: string,
              public couverture: Photo,
              public isPublic: boolean,
              public newUserEmail: string) {
  }
}

export class getDTO {
  constructor(public id: number,
              public destination: string,
              public photos: Photo[]) {
  }
}

export class Photo {
  constructor(public id: number,
              public filename: string,
              public mimeType: string) {
  }
}
