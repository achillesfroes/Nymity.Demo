import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { OrderService } from '../services/order.service';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnChanges {

  @Input() OrderId: number;
  orderDetails:any;


  constructor(private orderService:OrderService) { }

  ngOnChanges(changes: SimpleChanges) {

    if (changes['OrderId']) {

      this.getOrderDetails();
    }
  }

  getOrderDetails(){
    this.orderService.getById(this.OrderId).subscribe(orderDetails => {
      this.orderDetails = orderDetails;
    });
  }

}
