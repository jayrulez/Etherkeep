import { provideRouter, RouterConfig } from '@angular/router';

import { IndexComponent } from './components/default/index.component';
import { HomeComponent } from './components/default/home.component';
import { SettingsComponent } from './components/users/settings.component';
import { SettingsHomeComponent } from './components/users/settings-home.component';
import { ChangePasswordComponent } from './components/users/change-password.component';
import { LoginComponent } from './components/users/login.component';
import { RegisterComponent } from './components/users/register.component';
import { ResetPasswordComponent } from './components/users/reset-password.component';
import { ConfirmResetPasswordComponent } from './components/users/confirm-reset-password.component';
import { AuthGuard } from './common/auth-guard';

export const routes: RouterConfig = [
  { path: '', component: IndexComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'confirm-reset-password', component: ConfirmResetPasswordComponent },
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
