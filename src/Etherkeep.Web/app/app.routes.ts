import { provideRouter, RouterConfig } from '@angular/router';

import { IndexComponent } from './components/default/index.component';
import { HomeComponent } from './components/default/home.component';
import { LoginComponent } from './components/account/login.component';
import { RegisterComponent } from './components/account/register.component';
import { AuthGuard } from './common/auth-guard';

export const routes: RouterConfig = [
  { path: '', component: IndexComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
