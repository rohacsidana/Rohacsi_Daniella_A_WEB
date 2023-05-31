import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TesztService {
  tesztData: Teszt[] = [];
  tesztDataChanged: Subject<Teszt[]> = new Subject();

  setTesztData(tesztek: Teszt[]) {
    this.tesztData = tesztek;
    this.tesztDataChanged.next(this.tesztData.slice());
  }

  getTesztData() {
    return this.tesztData.slice();
  }
}
export interface Teszt {
  id: number;
  kerdes: string;
  v1: string;
  v2: string;
  v3: string;
  v4: string;
  helyes: string;
  kategoriaId: number;
  timestamps: Date;
  kategoria: {
    id: number;
    kategorianev: string;
    timestamps: Date;
  };
}
