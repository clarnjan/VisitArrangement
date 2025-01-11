import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { MessageDetails, MessageInfo, UserMessages } from '../../Interfaces/Message/Message';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class MessagesApiService {
  public constructor(private apiService: ApiService) { }

  public getMessageInfos(userId: number): Observable<MessageInfo[]> {
    return this.apiService.get<MessageInfo[]>(`messages/${userId}`);
  }

  public getMessageDetails(userId: number, otherUserId: number): Observable<UserMessages> {
    return this.apiService.get<UserMessages>(`messages/${userId}/details/${otherUserId}`);
  }

  public sendMessage(userId: number, otherUserId: number, messageText: string): Observable<MessageDetails> {
    return this.apiService.post<MessageDetails>(`messages/${userId}/details/${otherUserId}`, messageText);
  }
}
