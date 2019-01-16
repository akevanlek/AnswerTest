import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {

  principleinput : number = 0;
  yearinput : number = 1;
  loans :Loan[];

  constructor(public navCtrl: NavController, public http: HttpClient) {

  }

  loan() { 
    /*if(this.interest <0){return}*/
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:44336/api/Loan/Loan/"+ this.principleinput+"/"+this.yearinput,option)
      .subscribe((data: Loan[]) => {
        this.loans = data
        this.principleinput = 0;
        this.yearinput =0;

      }, error => {
        // If error
      });
  }

}

export class Loan {
  public year :number;
  public principle :number;  	
  public interest :number;
  public totalInterest :number;
  public payPerYear :number;
}

