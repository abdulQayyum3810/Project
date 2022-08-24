import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { dataModel } from '../models/dataModel';

@Injectable({
  providedIn: 'root'
})
export class ManageDataService {

  constructor(private http:HttpClient) { }

  
  getCountries():Observable<string[]>{
    return this.http.get<string[]>("/api/Penalty/Countries")
  }
  getPenalty(data:dataModel):Observable<number>{
    return this.http.post<number>("/api/Penalty/PalentyCalc",data)
  }

}
