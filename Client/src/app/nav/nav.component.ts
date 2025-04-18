import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  public isUserAuthenticated: boolean = false;
  public userId: number | undefined;

  constructor(private authService: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
    if (typeof window !== 'undefined') {
      const userInfo = localStorage.getItem('current-user');
      if (userInfo) {
        this.userId = JSON.parse(userInfo).userId;
        this.authService.sendAuthStateChangeNotification(true);
      }
    }
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }
}
