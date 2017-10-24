import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  page:number;
  total:number;
  orders:any;
  orderSelected:any;

  constructor(private orderService:OrderService) { }

  ngOnInit() {
    this.page = 1;
    this.getOrders()
  }

  getOrders(){
    this.orderSelected = null;

    this.orderService.getAll(this.page).subscribe(orders => {
      this.orders =  orders.List;
      this.total = orders.TotalCount/10;
    });
  }

  onSelect(order: any): void {
    if (this.orderSelected === order) {
      this.orderSelected = null;
    }
    else{
      this.orderSelected = order;
    }
  }

}
