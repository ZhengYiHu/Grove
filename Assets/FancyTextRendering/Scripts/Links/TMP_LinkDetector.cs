using TMPro;
using UnityEngine;

public static class TMP_LinkDetector
{
    public static int FindIntersectingLink(TMP_Text text, Vector3 position, Camera camera)
    {
        Transform rectTransform = text.transform;

        // Convert position into Worldspace coordinates
        TMP_TextUtilities.ScreenPointToWorldPointInRectangle(rectTransform, position, camera, out position);

        for (int i = 0; i < text.textInfo.linkCount; i++)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[i];

            bool isBeginRegion = false;

            Vector3 bl = Vector3.zero;
            Vector3 tl = Vector3.zero;
            Vector3 br = Vector3.zero;
            Vector3 tr = Vector3.zero;

            // Iterate through each character of the word
            for (int j = 0; j < linkInfo.linkTextLength; j++)
            {
                int characterIndex = linkInfo.linkTextfirstCharacterIndex + j;
                TMP_CharacterInfo currentCharInfo = text.textInfo.characterInfo[characterIndex];
                int currentLine = currentCharInfo.lineNumber;

                // Check if Link characters are on the current page
                if (text.overflowMode == TextOverflowModes.Page && currentCharInfo.pageNumber + 1 != text.pageToDisplay) continue;

                if (isBeginRegion == false)
                {
                    isBeginRegion = true;

                    bl = rectTransform.TransformPoint(new Vector3(currentCharInfo.bottomLeft.x, currentCharInfo.descender, 0));
                    tl = rectTransform.TransformPoint(new Vector3(currentCharInfo.bottomLeft.x, currentCharInfo.ascender, 0));

                    //Debug.Log("Start Word Region at [" + currentCharInfo.character + "]");

                    // If Word is one character
                    if (linkInfo.linkTextLength == 1)
                    {
                        isBeginRegion = false;

                        br = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.descender, 0));
                        tr = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.ascender, 0));

                        // Check for Intersection
                        if (PointIntersectRectangle(position, bl, tl, tr, br))
                            return i;

                        //Debug.Log("End Word Region at [" + currentCharInfo.character + "]");
                    }
                }

                // Last Character of Word
                if (isBeginRegion && j == linkInfo.linkTextLength - 1)
                {
                    isBeginRegion = false;
                    br = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.descender, 0));
                    tr = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.ascender, 0));

                    if (br == tr && tr == tl)
                    {
                        continue;
                    }
                    // Check for Intersection
                    if (PointIntersectRectangle(position, bl, tl, tr, br))
                    {
                        return i;
                    }

                    //Debug.Log("End Word Region at [" + currentCharInfo.character + "]");
                }
                // If Word is split on more than one line.
                else if (isBeginRegion && currentLine != text.textInfo.characterInfo[characterIndex + 1].lineNumber)
                {
                    isBeginRegion = false;

                    br = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.descender, 0));
                    tr = rectTransform.TransformPoint(new Vector3(currentCharInfo.topRight.x, currentCharInfo.ascender, 0));

                    // Check for Intersection
                    if (PointIntersectRectangle(position, bl, tl, tr, br))
                        return i;

                    //Debug.Log("End Word Region at [" + currentCharInfo.character + "]");
                }
            }

            //Debug.Log("Word at Index: " + i + " is located at (" + bl + ", " + tl + ", " + tr + ", " + br + ").");

        }

        return -1;
    }


    private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Vector3 ab = b - a;
        Vector3 am = m - a;
        Vector3 bc = c - b;
        Vector3 bm = m - b;

        float abamDot = Vector3.Dot(ab, am);
        float bcbmDot = Vector3.Dot(bc, bm);

        return 0 <= abamDot && abamDot <= Vector3.Dot(ab, ab) && 0 <= bcbmDot && bcbmDot <= Vector3.Dot(bc, bc);
    }
}
