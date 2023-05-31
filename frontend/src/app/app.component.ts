import { Component, OnDestroy, OnInit } from '@angular/core';
import { Teszt, TesztService } from './teszt.service';
import { Kategoria, KategoriaService } from './kategoria.service';
import { Subscription } from 'rxjs';
import { DatastorageService } from './datastorage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./bootstrap.css', './app.component.css'],
})
export class AppComponent implements OnInit, OnDestroy {
  isMobileLayout = false;

  tesztData: Teszt[] = this.tesztService.getTesztData();
  tesztDataSub: Subscription = new Subscription();

  kategData: Kategoria[] = this.kategoriaService.getKategoriaData();
  kategDataSub: Subscription = new Subscription();

  valasztottKateg = -1;
  kerdesekToShow: Teszt[] = this.tesztData;

  pontszam: number = 0;
  megvalaszoltKerdesekSzama = 0;

  kesz: boolean = false;

  constructor(
    private kategoriaService: KategoriaService,
    private tesztService: TesztService,
    private dataStorage: DatastorageService
  ) {}

  ngOnInit(): void {
    window.onresize = () => (this.isMobileLayout = window.innerWidth <= 991);

    this.tesztDataSub = this.tesztService.tesztDataChanged.subscribe(
      (data: Teszt[]) => {
        this.tesztData = data;
        console.log('got tesztek');

        this.kategValaszt();
      }
    );

    this.kategDataSub = this.kategoriaService.kategoriaDataChanged.subscribe(
      (data: Kategoria[]) => {
        console.log('got kategoriak');
        this.kategData = data;
      }
    );
    this.dataStorage.fetchKategoriak();
    this.dataStorage.fetchTesztek();
    this.kerdesekToShow = this.tesztData;
  }

  kategValaszt() {
    this.valasztottKateg = +(<HTMLInputElement>(
      document.getElementById('kategoriak')
    )).value;
    console.log('választott kategóriák: ' + this.valasztottKateg);

    if (this.valasztottKateg == -1) {
      this.kerdesekToShow = this.tesztData;
    } else {
      this.kerdesekToShow = [];
      this.tesztData.forEach((t) => {
        if (t.kategoriaId === this.valasztottKateg) {
          this.kerdesekToShow.push(t);
        }
      });
    }
    this.kesz = false;
    this.megvalaszoltKerdesekSzama = 0;
    this.pontszam = 0;
    this.tesztData.forEach((t) => {
      for (let i = 1; i <= 4; i++) {
        if (
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.hasAttribute('disabled')
        ) {
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.removeAttribute('disabled');
        }
        if (
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.classList.contains('helyes')
        ) {
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.classList.remove('helyes');
        }
        if (
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.classList.contains('helytelen')
        ) {
          (<HTMLInputElement>(
            document.getElementById(t.id + '-v' + i)
          ))?.classList.remove('helytelen');
        }
      }
    });
  }

  pontoz(teszt: Teszt, valasz: string, hanyadik: string) {
    this.megvalaszoltKerdesekSzama++;
    if (teszt.helyes === valasz) {
      this.pontszam++;
      (<HTMLInputElement>(
        document.getElementById(teszt.id + '-' + hanyadik)
      )).classList.add('helyes');
    } else {
      (<HTMLInputElement>(
        document.getElementById(teszt.id + '-' + hanyadik)
      )).classList.add('helytelen');
    }

    for (let i = 1; i <= 4; i++) {
      (<HTMLInputElement>(
        document.getElementById(teszt.id + '-v' + i)
      )).setAttribute('disabled', '');
    }
  }

  keszenVan() {
    this.kesz = true;
  }

  ngOnDestroy(): void {}
}
