import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  page:number;
  orders:any;

  constructor(private orderService:OrderService) { }

  ngOnInit() {
    this.page = 1;
    this.getOrders()
  }

  changePage(count:number) {

    if(this.page > 0){
      this.page += count;
    }

    this.getOrders()
  }

  hasPrevious() : boolean {
    return !(this.page == 1);
  }

  getOrders(){
    this.orderService.getAll(this.page).subscribe(orders => { this.orders =  orders});
  }

}
