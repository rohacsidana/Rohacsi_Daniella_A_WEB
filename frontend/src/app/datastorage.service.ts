import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Kategoria, KategoriaService } from './kategoria.service';
import { Teszt, TesztService } from './teszt.service';
import { map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DatastorageService {
  constructor(
    private http: HttpClient,
    private kategoriaService: KategoriaService,
    private tesztService: TesztService
  ) {}

  fetchKategoriak() {
    console.log('fetching kategoriak');

    this.http
      .get<
        {
          id: number;
          kategorianev: string;
          timestamps: Date;
        }[]
      >(URL + 'kategoria')
      .pipe(
        map((kategoriak) => {
          const kategData = kategoriak.map((kat) => {
            const sor: Kategoria = {
              id: kat.id,
              kategorianev: kat.kategorianev,
              timestamps: kat.timestamps,
            };
            return { ...sor };
          });
          return kategData;
        }),
        tap({
          next: (data) => {
            this.kategoriaService.setKategoriaData(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }
  fetchTesztek() {
    console.log('fetching tesztek');

    this.http
      .get<
        {
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
        }[]
      >(URL + 'teszt')
      .pipe(
        map((tesztek) => {
          const tesztData = tesztek.map((teszt) => {
            const sor: Teszt = {
              id: teszt.id,
              kerdes: teszt.kerdes,
              v1: teszt.v1,
              v2: teszt.v2,
              v3: teszt.v3,
              v4: teszt.v4,
              helyes: teszt.helyes,
              kategoriaId: teszt.kategoriaId,
              timestamps: teszt.timestamps,
              kategoria: {
                id: teszt.kategoria.id,
                kategorianev: teszt.kategoria.kategorianev,
                timestamps: teszt.kategoria.timestamps,
              },
            };
            return { ...sor };
          });
          return tesztData;
        }),
        tap({
          next: (data) => {
            this.tesztService.setTesztData(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }
}
export const URL = 'https://localhost:7206/';
