import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from "./layout/header/header.component";
import { Product } from './shared/models/product';
import { ShopService } from './core/services/shop.service';
import { ShopComponent } from "./features/shop/shop.component";

@Component({
  selector: 'app-root',
  //imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [HeaderComponent, ShopComponent],
})
export class AppComponent {
  
  title = 'Skinet';
}
