import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../http.service";
import {Voyage} from "../Voyage";
import {ActivatedRoute} from "@angular/router";
@Component({
  selector: 'app-voyage',
  templateUrl: './voyage.component.html',
  styleUrls: ['./voyage.component.scss']
})
export class VoyageComponent implements OnInit {
  voyage: Voyage;
  idVoyage: string | null = this.route.snapshot.paramMap.get("id");
  @ViewChild('couverture',{static:false}) couverture: any;
  @ViewChild('filePhoto',{static:false}) filePhoto: any;
  constructor(private http: HttpService,
              private route: ActivatedRoute) {
    this.voyage = new Voyage(0, '', false, true);
  }

  async ngOnInit() {
    if (this.idVoyage == null) {
      throw new Error("id is null");
    }
    this.voyage = await this.http.GetVoyageById(+this.idVoyage);
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
