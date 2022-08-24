import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { dataModel } from '../models/dataModel';
import { ManageDataService } from '../services/manage-data.service';

@Component({
  selector: 'app-penalty-calculator',
  templateUrl: './penalty-calculator.component.html',
  styleUrls: ['./penalty-calculator.component.css']
})
export class PenaltyCalculatorComponent implements OnInit {
countries!:string[];
penalty:number

  constructor(private dataSevice:ManageDataService) { }
penaltyForm=new FormGroup({});
  ngOnInit() {
    this.dataSevice.getCountries().subscribe(data=>{this.countries=data})
  }
  getAndPopulatePenalty(){
    let a:dataModel={Checkout:new Date("2022-08-08"),Checkin:new Date("2022-08-11"),CountryName:"Pakistan"}
    this.dataSevice.getPenalty(a).subscribe(data=>this.penalty=data)
  }

}
