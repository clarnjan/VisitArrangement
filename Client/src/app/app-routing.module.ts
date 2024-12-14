import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProfilesListComponent } from './profiles-list/profiles-list.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
    { path: 'authentication',
      loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
    },
    {
      path: 'home',
      component: ProfilesListComponent
    },
    {
      path: 'profile',
      component: ProfileComponent
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
