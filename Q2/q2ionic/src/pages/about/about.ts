import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {
  products :Product[];
  myorder :Order = new Order();
  constructor(public navCtrl: NavController,public http: HttpClient) {
    this.myorder.products=[]; 
  }
  ionViewDidEnter(){
    this.getproduct();
    this.getorder();
  }
  addtocart(input){
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:44395/api/Order/AddOrder/"+ input,option)
      .subscribe((data: Order) => {     
        this.myorder = data;
        console.log(data);
      }, error => {
        // If error
      });
  }
  getproduct(){
    this.http.get("https://localhost:44395/api/Order/GetStoreProducts")
    .subscribe((data: Product[]) => {  
      this.products = data;
    
    },
      error => {
        // ERROR: Do something
      });

  }
  getorder(){
    this.http.get("https://localhost:44395/api/Order/GetOrder")
    .subscribe((data: Order) => {  
      this.myorder = data;    
    },
      error => {
        // ERROR: Do something
      });

  }

}

export class Product {
  public name :string;
  public id :number;  	
  public price :number;
}

export class ProductOrder {
  public product :Product;	
  public quantity :number;
}

export class Order {
  public products :ProductOrder[];
  public totalPrice :number;  	
  public discount :number;
  public checkOutPrice :number;
}

