import { MessageDetails, UserMessages } from './../Interfaces/Message/Message';
import { MessagesApiService } from './../shared/services/messages-api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageInfo } from '../Interfaces/Message/Message';
import { ArrangementApiService } from '../shared/services/arrangement-api.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.scss'
})
export class MessagesComponent implements OnInit {
  public isCurrentUser = true;
  public userId?: number;
  public otherUserId?: number;
  public messageInfos: MessageInfo[] = [];
  public userMessages?: UserMessages;
  public newMessage = '';

  constructor(private route: ActivatedRoute,
    private messagesApiService: MessagesApiService,
    private arrangementApiService: ArrangementApiService,
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
          this.userId = JSON.parse(tokenInfo).userId;
  				this.otherUserId = Number(params.get('userId'));
          this.isCurrentUser = this.userId === this.otherUserId;
          
          this.messagesApiService.getMessageInfos(this.userId!)
            .subscribe((result) => {
              this.messageInfos = result;
              console.log('messageInfos');
              console.log(this.messageInfos);
            });

          if (!this.isCurrentUser) {
            this.getOtherUserMessages();
          }
  			},
  		});
  }

  public selectUser(otherUserId: number) {
    this.otherUserId = otherUserId;
    this.getOtherUserMessages();
  }

  private getOtherUserMessages() {
    this.messagesApiService.getMessageDetails(this.userId!, this.otherUserId!)
      .subscribe((result) => {
        this.userMessages = result;
        console.log('userMessages');
        console.log(this.userMessages);
      })
  }

  public sendMessage() {
    this.messagesApiService.sendMessage(this.userId!, this.otherUserId!, this.newMessage)
      .subscribe((result) => {
        this.newMessage = '';
        this.userMessages?.messages.push(result);
        this.messageInfos.find(x => x.userId === this.otherUserId)!.messageText = result.messageText;
      })
  }

  public arrangeVisit() {
    this.arrangementApiService.arrangeVisit(this.userId!, this.otherUserId!)
      .subscribe(() => {
        this.userMessages!.visitAgreedByCurrentUser = true;
      });
  }
}
