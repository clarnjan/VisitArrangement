import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../Interfaces/User/UserProfile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
  public user: UserProfile | undefined;

  ngOnInit(): void {
    if (typeof window !== 'undefined') {
      const tokenInfo = localStorage.getItem('current-user');
      if (tokenInfo) {
        const userInfo = JSON.parse(tokenInfo).user;
      }
    }
  }
}
