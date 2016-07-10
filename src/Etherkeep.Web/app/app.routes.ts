import { provideRouter, RouterConfig } from '@angular/router';

import { IndexComponent } from './components/default/index.component';
import { HomeComponent } from './components/default/home.component';
import { SettingsComponent } from './components/account/settings.component';
import { SettingsHomeComponent } from './components/account/settings-home.component';
import { ChangePasswordComponent } from './components/account/change-password.component';
import { LoginComponent } from './components/account/login.component';
import { RegisterComponent } from './components/account/register.component';
import { AuthGuard } from './common/auth-guard';

export const routes: RouterConfig = [
  { path: '', component: IndexComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'settings', 
    component: SettingsComponent,
    children: [
      { path: '', component: SettingsHomeComponent },
      { path: 'change-password', component: ChangePasswordComponent }
	  ], 
    canActivate: [AuthGuard]
  },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
