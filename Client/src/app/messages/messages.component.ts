import { MessagesApiService } from './../shared/services/messages-api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageInfo } from '../Interfaces/Message/Message';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.scss'
})
export class MessagesComponent implements OnInit {
  public isCurrentUser = true;
  public messages: MessageInfo[] = [];

  constructor(private route: ActivatedRoute,
    private messagesApiService: MessagesApiService,
    private router: Router
  ) {  }

  redirectToHome() {
    this.router.navigate(['/home']);
  }

  ngOnInit(): void {
    if (typeof window === 'undefined'){
      return;
    }
    const tokenInfo = localStorage.getItem('current-user');
    if (!tokenInfo) {
      return;
    }
    this.route.paramMap
  		.subscribe({
  			next: params => {
  				const userId = Number(params.get('userId'));
          this.isCurrentUser = JSON.parse(tokenInfo).userId === userId;
          
          this.messagesApiService.getMessages(userId)
            .subscribe((result) => {
              this.messages = result;
            });
  			},
  		});
  }
}
