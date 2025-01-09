import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProfilesListComponent } from './profiles-list/profiles-list.component';
import { ProfileComponent } from './profile/profile.component';
import { MessagesComponent } from './messages/messages.component';

const routes: Routes = [
    { path: 'authentication',
      loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
    },
    { path: '', redirectTo: 'home', pathMatch: 'prefix', },
    {
      path: 'home',
      component: ProfilesListComponent
    },
    {
      path: 'profiles/:userId',
      component: ProfileComponent
    },
    {
      path: 'messages/:userId',
      component: MessagesComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
