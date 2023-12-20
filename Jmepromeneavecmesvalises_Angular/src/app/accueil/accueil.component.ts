import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../http.service";
import {Photo, ShareDTO, Voyage} from "../Voyage";
import {Router} from "@angular/router";

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {
  voyages: Voyage[] = [];
  newVoyage: Voyage = new Voyage(0, '',new Photo(0,'',''),false, true);
  shareVoyageId: number = 0;
  shareUserEmail:string = '';

  @ViewChild('fileUpload',{static:false}) fileUpload: any;

  constructor(public http: HttpService,
              public router:Router) {
  }


  async ngOnInit(): Promise<void> {
    this.voyages = await this.http.GetAllVoyages();
  }

  async creerVoyage() {
    let formdata = new FormData();
    formdata.append('monImage', this.fileUpload.nativeElement.files[0]);

    let res: Voyage = await this.http.CreerNouveauVoyage(this.newVoyage,formdata)
    this.voyages.push(res);
    this.newVoyage = new Voyage(0, '', new Photo(0,'',''), false, true);
  }

  async delete(id: number) {
    await this.http.delete(id);
    location.reload();
  }

  showModal(id: number) {
    let modal = document.getElementById("modal");
    if (modal != null)
      modal.style.display = "flex";
    this.shareVoyageId = id;
  }

  closeModal() {
    let modal = document.getElementById("modal");
    if (modal != null)
      modal.style.display = "none";
  }

  async share() {
    let voyage:Voyage = <Voyage>this.voyages.find(v => v.id == this.shareVoyageId)
    let dto = new ShareDTO(voyage.id, voyage.destination, voyage.couverture, voyage.isPublic,this.shareUserEmail);
    await this.http.share(dto);
    location.reload();

    let modal = document.getElementById("modal");
    if (modal != null)
      modal.style.display = "none";
  }

  infoVoyage(id:number){
    this.router.navigate(['/Voyage',id]);
  }

  protected readonly localStorage = localStorage;
}
