import { provideRouter, RouterConfig } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { LoginComponent } from './components/auth/login.component';
import { RegistrationComponent } from './components/auth/registration.component';

export const routes: RouterConfig = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
