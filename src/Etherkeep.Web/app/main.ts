import { bootstrap }    from '@angular/platform-browser-dynamic';
import { AppComponent } from './components/app.component';
import { HTTP_PROVIDERS } from '@angular/http';
import { APP_ROUTER_PROVIDERS } from './app.routes';
import { HttpClient } from './common/http-client';
import { AuthGuard } from './common/auth-guard';
import { AuthService } from './services/auth.service';
import { HttpService } from './services/http.service';
import { AccountService } from './services/account.service';

bootstrap(AppComponent, [
  APP_ROUTER_PROVIDERS,
  HTTP_PROVIDERS,
  AuthGuard,
  AuthService,
  HttpClient,
  AccountService,
  HttpService
])
.catch(err => console.error(err));
