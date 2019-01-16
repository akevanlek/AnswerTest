import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  input: number = 0;
  interest: number = 0;
  result: string;

  constructor(
    public navCtrl: NavController,
    public http: HttpClient) {
      this.getinterest();
  }

  setinterest() { 
    /*if(this.interest <0){return}*/
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:44336/api/Loan/SetInterest/"+ this.input,option)
      .subscribe((data:  any) => {
        
        this.interest = data.interest;
        this.input =0;

      }, error => {
        // If error
      });
  }
  getinterest(){
    this.http.get("https://localhost:44336/api/Loan/GetInterest")
    .subscribe((data: any) => {  
      this.interest = data.interest
    },
      error => {
        // ERROR: Do something
      });

  }

}
