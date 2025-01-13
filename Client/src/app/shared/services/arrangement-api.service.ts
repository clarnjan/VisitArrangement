import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ArrangementApiService {
  public constructor(private apiService: ApiService) { }

  public arrangeVisit(userId: number, otherUserId: number): Observable<{}> {
    return this.apiService.post<{}>(`arrangement/${userId}/arrange/${otherUserId}`);
  }
}
