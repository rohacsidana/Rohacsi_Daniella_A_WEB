import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class KategoriaService {
  kategoriaData: Kategoria[] = [];
  kategoriaDataChanged: Subject<Kategoria[]> = new Subject();

  setKategoriaData(kategoriak: Kategoria[]) {
    this.kategoriaData = kategoriak;
    this.kategoriaDataChanged.next(this.kategoriaData.slice());
  }

  getKategoriaData() {
    return this.kategoriaData.slice();
  }
}
export interface Kategoria {
  id: number;
  kategorianev: string;
  timestamps: Date;
}
