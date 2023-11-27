import {Component, OnInit} from '@angular/core';
import {HttpService} from "../http.service";
import {ShareDTO, Voyage} from "../Voyage";

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {
  voyages: Voyage[] = [];
  newVoyage: Voyage = new Voyage(0, '', '', false, true);
  shareVoyageId: number = 0;
  shareUserEmail:string = '';

  constructor(public http: HttpService) {
  }


  async ngOnInit(): Promise<void> {
    this.voyages = await this.http.GetAllVoyages();
  }

  async creerVoyage() {
    if (this.newVoyage.img.trim() == "") {
      this.newVoyage.img = "https://pbs.twimg.com/profile_images/1034857726814441479/-uDIzZ5O_400x400.jpg";
    }
    let res: Voyage = await this.http.CreerNouveauVoyage(this.newVoyage)
    this.voyages.push(res);
    this.newVoyage = new Voyage(0, '', '', false, true);
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
    let dto = new ShareDTO(voyage.id, voyage.img, voyage.destination, voyage.isPublic,this.shareUserEmail);
    await this.http.share(dto);
    location.reload();

    let modal = document.getElementById("modal");
    if (modal != null)
      modal.style.display = "none";
  }

  protected readonly localStorage = localStorage;
}
