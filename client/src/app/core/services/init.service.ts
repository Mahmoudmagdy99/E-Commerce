import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { forkJoin, of } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
  
// Service to initialize application state
export class InitService {
  
  // Inject services
  private cartService = inject(CartService);
  private accountService = inject(AccountService);

  // Initialize application state
  init() {

    // Get cart ID from local storage
    const cartId = localStorage.getItem('cart_id');
    
    // Fetch cart and user info
    const cart$ = cartId ? this.cartService.getCart(cartId) : of(null);

    // Return combined observables
    return forkJoin({
      cart: cart$,
      user: this.accountService.getUserInfo()
    });
  }

}
