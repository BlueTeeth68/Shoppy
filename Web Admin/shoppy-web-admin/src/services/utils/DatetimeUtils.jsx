//lấy múi giờ utc hiện tại
export const getUtcOffset = () => {
    const now = new Date();
    const utcOffset = now.getTimezoneOffset() / -60;
    return utcOffset;
};

///convert utc time "dd/mm/yyyy HH:mm:ss" to local time
export const convertUtcToLocalTime = (dateTimeString) => {
    const utcOffset = getUtcOffset();

    const [dateStr, timeStr] = dateTimeString.split(" ");
    const [day, month, year] = dateStr.split("/");
    const [hoursStr, minutesStr, secondsStr] = timeStr.split(":");

    const date = new Date(
        `${month}/${day}/${year} ${hoursStr}:${minutesStr}:${secondsStr}`
    );

    date.setHours(date.getHours() + utcOffset);
    return date;
};


//format server date to "DD/MM/YYYY HH:mm"
export function formatDateV1(dateString) {
    if (!dateString) {
        return "";
    }
    const utcOffset = getUtcOffset();

    const date = new Date(dateString);
    date.setHours(date.getHours() + utcOffset);

    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');

    return `${day}/${month}/${year} ${hours}:${minutes}`;
}