import { bootstrap }    from '@angular/platform-browser-dynamic';
import { AppComponent } from './components/app.component';
import { HTTP_PROVIDERS } from '@angular/http';
import { APP_ROUTER_PROVIDERS } from './app.routes';
import { HttpClient } from './common/http-client';
import { AuthGuard } from './common/auth-guard';
import { AuthService } from './services/auth.service';
import { ConnectivityService } from './services/connectivity.service';
import { HttpService } from './services/http.service';
import { UsersService } from './services/users.service';
import { ActivitiesService } from './services/activities.service';
import { WalletsService } from './services/wallets.service';

bootstrap(AppComponent, [
  APP_ROUTER_PROVIDERS,
  HTTP_PROVIDERS,
  HttpClient,
  AuthGuard,
  ConnectivityService,
  HttpService,
  AuthService,
  UsersService,
  ActivitiesService,
  WalletsService
])
.catch(err => console.error(err));
