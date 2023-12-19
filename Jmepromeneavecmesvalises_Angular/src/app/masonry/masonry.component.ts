import { AfterViewInit, Component, ElementRef, Input, QueryList, ViewChild, ViewChildren } from '@angular/core';

declare var Masonry: any;
declare var imagesLoaded: any;

@Component({
  selector: 'app-masonry',
  templateUrl: './masonry.component.html',
  styleUrls: ['./masonry.component.scss']
})
export class MasonryComponent {

  constructor() { }

  @Input() images: string[] = [];
  @ViewChild('masongrid') masongrid?: ElementRef;
  @ViewChildren('masongriditems') masongriditems?: QueryList<any>;

  ngAfterViewInit() {
    if (this.masongriditems == null) {return;}
    this.masongriditems.changes.subscribe(e => {
      this.initMasonry();
    });

    // le ngFor est déjà fait
    if(this.masongriditems.length > 0) {
      this.initMasonry();
    }
  }

  initMasonry() {
    if (this.masongrid == null) {return;}
    var grid = this.masongrid.nativeElement;

    var msnry = new Masonry( grid, {
      itemSelector: '.grid-item',
      columnWidth: 320,
    });

    imagesLoaded( grid ).on( 'progress', function() {
      msnry.layout();
    });
  }
}
