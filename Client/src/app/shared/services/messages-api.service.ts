import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { MessageInfo } from '../../Interfaces/Message/Message';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class MessagesApiService {
  public constructor(private apiService: ApiService) { }

  public getMessages(userId: number): Observable<MessageInfo[]> {
    return this.apiService.get<MessageInfo[]>(`messages/${userId}`);
  }
}
