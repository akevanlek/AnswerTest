import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  nameinput : string;
  priceinput : number;
  products :Product[];

  constructor(public navCtrl: NavController,public http: HttpClient) {
    this.getproduct();
  }

  getproduct(){
    this.http.get("https://localhost:44395/api/Order/GetStoreProducts")
    .subscribe((data: Product[]) => {  
      this.products = data;
      this.priceinput = 0;  
    },
      error => {
        // ERROR: Do something
      });

  }

  addproduct(){
    let option = { "headers": { "Content-Type": "application/json" } };
    let model = {
      name : this.nameinput,     
      price : this.priceinput
  }; // model here
    this.http.post("https://localhost:44395/api/Order/AddStoreProduct",model,option)
      .subscribe((data: Product[]) => {
        this.products = data;
        this.priceinput = 0;
        this.nameinput = "";

      }, error => {
        // If error
      });
  }

}

export class Product {
  public name :string;
  public id :number;  	
  public price :number;
}
