import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../http.service";
import {getDTO, Voyage} from "../Voyage";
import {ActivatedRoute} from "@angular/router";
@Component({
  selector: 'app-voyage',
  templateUrl: './voyage.component.html',
  styleUrls: ['./voyage.component.scss']
})
export class VoyageComponent implements OnInit {
  voyage: getDTO;
  photos: string[] = [];
  idVoyage: string | null = this.route.snapshot.paramMap.get("id");
  @ViewChild('couverture',{static:false}) couverture: any;
  @ViewChild('filePhoto',{static:false}) filePhoto: any;
  constructor(private http: HttpService,
              private route: ActivatedRoute) {
    this.voyage = new getDTO(0, '', []);
  }

  async ngOnInit() {
    if (this.idVoyage == null) {
      throw new Error("id is null");
    }
    this.voyage = await this.http.GetVoyageById(+this.idVoyage);
    for (let photo of this.voyage.photos) {
      this.photos.push("https://localhost:7023/api/Photos/" + photo.id.toString());
    }
  }

  async editCouverture() {
    let formdata = new FormData();
    formdata.append('monImage', this.couverture.nativeElement.files[0]);
    await this.http.editCouverture(formdata, this.voyage.id);
    location.reload()
  }

  async ajouterPhoto() {
    let formdata = new FormData();
    formdata.append('monImage', this.filePhoto.nativeElement.files[0]);
    await this.http.ajoutPhoto(formdata, this.voyage.id);
    location.reload()
  }
}
