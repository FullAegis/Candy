import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { CartComponent } from './components/cart/cart.component';
import { OrderHistoryComponent } from './components/order/order-history/order-history.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { AuthGuard } from './services/auth/auth.guard'; // Ensure this path is correct

export const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'products/:id', component: ProductDetailComponent },
  {
    path: 'cart',
    component: CartComponent,
    canActivate: [AuthGuard] // Added AuthGuard
  },
  {
    path: 'order-history',
    component: OrderHistoryComponent,
    canActivate: [AuthGuard] // Added AuthGuard
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard] // Added AuthGuard
  },
  // Future admin routes will also use an AdminGuard here
];
