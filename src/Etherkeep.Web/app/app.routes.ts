import { provideRouter, RouterConfig } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { LoginComponent } from './components/account/login.component';
import { RegisterComponent } from './components/account/register.component';
import { AuthGuard } from './common/auth-guard';

export const routes: RouterConfig = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
