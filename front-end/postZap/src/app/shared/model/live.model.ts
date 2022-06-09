import { SafeResourceUrl } from '@angular/platform-browser';

export class Live {
    id: string | undefined;
    liveName: string | undefined;
    channelName: string | undefined;
    liveDate!: string;
    liveTime: string | undefined;
    liveLink!: string;
    registrationDate: string | undefined;
    urlSafe: SafeResourceUrl | undefined;
}
